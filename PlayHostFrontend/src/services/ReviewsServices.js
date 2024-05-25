import { ApiConnection } from "./ApiConnection";

export class ReviewsServices {
  static async GetReviewsList(pageNumber, pageSize, isAscending) {
    const response = await ApiConnection.get(
      `Review${isAscending ? "?IsAscending=true" : ""}`
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
