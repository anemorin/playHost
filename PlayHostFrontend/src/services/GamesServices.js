import { ApiConnection } from "./ApiConnection";

export class GamesServices {
  static async GetGamesList(pageNumber, pageSize, isAscending) {
    const response = await ApiConnection.get(
      `Game${isAscending ? "?IsAscending=true" : ""}`
    );
    return response.data;
  }

  //   static async GetGameById(email, password) {
  //     const response = await ApiConnection.post("User/signIn", {
  //       email,
  //       password,
  //     });
  //     return response.data;
  //   }
}
