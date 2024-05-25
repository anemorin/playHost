import { ApiConnection } from "./ApiConnection";

export class SubscriptionsServices {
  static async GetSubscriptionsList(pageNumber, pageSize, isAscending) {
    const response = await ApiConnection.get(
      `Subscription?IsAscending=${isAscending ? true : false}${pageNumber ? `&PageNumber=${pageNumber}` : ""}${pageSize ? `&PageSize=${pageSize}` : ""}`
    );
    return response.data;
  }

  static async PostSubscription(price, serverId, gameId, userId) {
    const currentDate = new Date();
    const futureDate = new Date(currentDate);
    futureDate.setDate(currentDate.getDate() + 30);

    const response = await ApiConnection.post("Subscription", {
      price,
      startDate: currentDate.toISOString(),
      endDate: futureDate.toISOString(),
      serverId,
      gameId,
      userId,
    });
    return response.status;
  }

  static async Delete(id) {
    const response = await ApiConnection.delete(`Subscription/${id}`);
    return response.data;
  }

  static async AddDays(id) {
    const response = await ApiConnection.put(`Subscription/${id}`, {
      daysToAdd: 30,
    });
    return response.data;
  }
}
