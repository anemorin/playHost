import { ApiConnection } from "./ApiConnection";

export class NewsServices {
  static async GetNewsList(pageNumber, pageSize, isAscending) {
    const response = await ApiConnection.get(
      `New?IsAscending=${isAscending ? true : false}${pageNumber ? `&pageNumber=${pageNumber}` : ""}${pageSize ? `&pageSize=${pageSize}` : ""}`
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
