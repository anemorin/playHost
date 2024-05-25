import { makeAutoObservable } from "mobx";
import { GamesServices } from "../services/GamesServices";

class GameStore {
  constructor() {
    this.games = [];
    this.gamesTotalCount = 0;
    makeAutoObservable(this);
  }

  async getGames(page, pageSize, isAscending) {
    try {
      const response = await GamesServices.GetGamesList(
        page,
        pageSize,
        isAscending
      );
      if (response) {
        this.games = await response.entities;
        this.gamesTotalCount = response.totalCount;
      }
    } catch (error) {
      console.log(error);
    }
  }

  clearStore() {
    this.games = "";
    this.gamesTotalCount = "";
  }
}

export default GameStore;
