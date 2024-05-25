import { createContext } from "react";
import UserStore from "../stores/UserStore";
import GameStore from "../stores/GameStore";
import ServersStore from "../stores/ServersStore";
import ReviewsStore from "../stores/ReviewsStore";
import NewsStore from "../stores/NewsStore";
import SubscriptionsStore from "../stores/SubscriptionsStore";

export const storeContext = createContext({
  userStore: new UserStore(),
  gamesStore: new GameStore(),
  serversStore: new ServersStore(),
  reviewsStore: new ReviewsStore(),
  newsStore: new NewsStore(),
  subscriptionsStore: new SubscriptionsStore(),
});
