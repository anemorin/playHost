import { makeAutoObservable } from "mobx";
import { ServerServices } from "../services/ServerServices";

class ServersStore {
  constructor() {
    this.servers = [];
    this.serversTotalCount = 0;
    makeAutoObservable(this);
  }

  async getServers(page, pageSize, isAscending) {
    try {
      const response = await ServerServices.GetServerList(
        page,
        pageSize,
        isAscending
      );
      if (response) {
        this.servers = await response.entities;
        this.serversTotalCount = response.totalCount;
      }
    } catch (error) {
      console.log(error);
    }
  }

  clearStore() {
    this.servers = "";
    this.serversTotalCount = "";
  }
}

export default ServersStore;
