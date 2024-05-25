import { makeAutoObservable, runInAction } from "mobx";
import { AuthServices } from "../services/Auth/AuthServices";
import { getToken, removeToken } from "../services/ApiConnection";

class UserStore {
  constructor() {
    this.token = getToken();
    this.email = "";
    this.userId = "";
    this.refreshToken = localStorage.getItem("PlayHostToken") ?? undefined;
    makeAutoObservable(this);
  }

  async getUserData() {
    try {
      const response = await AuthServices.GetUserProfile();
      if (response) {
        runInAction(() => {
          this.userId = response.userId;
          this.userProfileId = response.userProfileId;
          this.email = response.email;
          this.firstName = response.firstName;
          this.lastName = response.lastName;
        });
      }
    } catch (error) {
      console.log(error);
      this.token = undefined;
      removeToken();
    }
  }

  async SignIn(username, password) {
    try {
      const response = await AuthServices.Login(username, password);
      if (response.data.jwtToken) {
        localStorage.setItem("PlayHostToken", response.data.jwtToken);
        this.token = response.data.jwtToken;
      } else if (response.status === "404") {
        return "Пользователь не найден";
      } else {
        return "Ошибка, неверный логин или пароль";
      }
    } catch (error) {
      console.log(error);
      return "Пользователь не найден";
    }
  }

  async Registrations(firstName, lastName, role, login, email, password) {
    try {
      const response = await AuthServices.Registration(
        firstName,
        lastName,
        role,
        login,
        email,
        password
      );
      if (response.data.result.succeeded === true) {
        await this.SignIn(email, password);
      } else {
        return "Пользователь с такими данными уже зарегестрирован";
      }
    } catch (error) {
      console.log(error);
      return "Пользователь с такими данными уже зарегестрирован";
    }
  }

  clearStore() {
    this.userId = "";
    this.userProfileId = "";
    this.email = "";
    this.firstName = "";
    this.lastName = "";
    this.token = "";
    this.refreshToken = "";
  }
}

export default UserStore;
