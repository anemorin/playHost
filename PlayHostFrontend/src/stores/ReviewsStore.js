import { makeAutoObservable } from "mobx";
import { ReviewsServices } from "../services/ReviewsServices";

class ReviewsStore {
  constructor() {
    this.reviews = [];
    this.reviewsTotalCount = 0;
    makeAutoObservable(this);
  }

  async getReviewsList(page, pageSize, isAscending) {
    try {
      const response = await ReviewsServices.GetReviewsList(
        page,
        pageSize,
        isAscending
      );
      if (response) {
        this.reviews = await response.entities;
        this.reviewsTotalCount = response.totalCount;
      }
    } catch (error) {
      console.log(error);
    }
  }

  clearStore() {
    this.reviews = "";
    this.reviewsTotalCount = "";
  }
}

export default ReviewsStore;
