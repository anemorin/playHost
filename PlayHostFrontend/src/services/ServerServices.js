import { ApiConnection } from "./ApiConnection";

export class ServerServices {
  static async GetServerList(pageNumber, pageSize, isAscending) {
    const response = await ApiConnection.get(
      `Server${isAscending ? "?IsAscending=true" : ""}`
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
