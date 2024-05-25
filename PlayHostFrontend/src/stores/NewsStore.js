import { makeAutoObservable } from "mobx";
import { NewsServices } from "../services/NewsServices";

class NewsStore {
  constructor() {
    this.news = [];
    this.newsTotalCount = 0;
    makeAutoObservable(this);
  }

  async getNews(page, pageSize, isAscending) {
    try {
      const response = await NewsServices.GetNewsList(
        page,
        pageSize,
        isAscending
      );
      if (response) {
        this.news = await response.entities;
        this.newsTotalCount = response.totalCount;
      }
    } catch (error) {
      console.log(error);
    }
  }

  clearStore() {
    this.news = "";
    this.newsTotalCount = "";
  }
}

export default NewsStore;
