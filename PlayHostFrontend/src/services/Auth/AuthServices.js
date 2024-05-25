import { ApiConnection } from "../ApiConnection";

export class AuthServices {
  static async Login(email, password) {
    const response = await ApiConnection.post("User/signIn", {
      email,
      password,
    });
    return response;
  }

  static async Registration(
    firstName,
    lastName,
    role,
    userName,
    email,
    password
  ) {
    const response = await ApiConnection.post("User/register", {
      firstName,
      lastName,
      role,
      userName,
      email,
      password,
    });
    return response;
  }

  static async GetUserProfile() {
    const response = await ApiConnection.get("User/currentUserInfo");
    return response.data;
  }
}
