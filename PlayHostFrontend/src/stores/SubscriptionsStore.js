import { makeAutoObservable } from "mobx";
import { SubscriptionsServices } from "../services/SubscriptionsServices";

class SubscriptionsStore {
  constructor() {
    this.subscriptions = [];
    this.subscriptionsTotalCount = 0;
    this.subscriptionInfo = {
      gameId: "",
      serverName: "",
      serverPrice: "",
      serverId: "",
      userId: "",
    };
    makeAutoObservable(this);
  }

  async getSubscriptions(page, pageSize, isAscending) {
    try {
      const response = await SubscriptionsServices.GetSubscriptionsList(
        page,
        pageSize,
        isAscending
      );
      if (response) {
        this.subscriptions = await response.entities;
        this.subscriptionsTotalCount = response.totalCount;
      }
    } catch (error) {
      console.log(error);
    }
  }

  async postSubscription(price, serverId, gameId, userId) {
    try {
      const response = await SubscriptionsServices.PostSubscription(
        price,
        serverId,
        gameId,
        userId
      );
      if (response) {
        return response;
      }
    } catch (error) {
      alert(`Ошибка: ${error.status}, попробуйте позже`);
      return false;
    }
  }

  setSubInfo(id, serverName, serverPrice, serverId, userId) {
    this.subscriptionInfo = {
      gameId: id ?? "",
      serverName: serverName ?? "",
      serverPrice: serverPrice ?? "",
      serverId: serverId ?? "",
      userId: userId ?? "",
    };
  }

  async delete(id) {
    try {
      const response = await SubscriptionsServices.Delete(id);
      if (response) {
        return response;
      }
    } catch (error) {
      console.warn(error);
    }
  }

  async addDays(id) {
    try {
      const response = await SubscriptionsServices.AddDays(id);
      if (response) {
        return response;
      }
    } catch (error) {
      console.warn(error);
    }
  }

  clearStore() {
    this.subscriptionInfo = "";
    this.subscriptions = "";
    this.subscriptionsTotalCount = "";
  }
}

export default SubscriptionsStore;
