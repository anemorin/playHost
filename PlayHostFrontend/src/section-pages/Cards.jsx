import React, { useEffect } from "react";
import { Helmet } from "react-helmet-async";
import { Parallax } from "react-parallax";
import { Link, useNavigate } from "react-router-dom";
import Preloader from "../layout/preloader";
import ScrollToTopBtn from "../layout/ScrollToTop";
import { createGlobalStyle } from "styled-components";
import { Formik, Form } from "formik";
import * as Yup from "yup";
import TextField from "./ui/fields/TextField";
import UseStores from "../hooks/useStores";
import { runInAction } from "mobx";

const image1 = "./img/background/2.webp";

const GlobalStyles = createGlobalStyle`
  .react-parallax-bgimage {
    transform: translate3d(-50%, 0, 0px) !important;
  }
  .h-100{
    height: 100vh !important;
  }
`;

const Cards = () => {
  const { subscriptionsStore, gamesStore } = UseStores();
  const navigate = useNavigate();

  useEffect(() => {
    const initialFetch = async () => {
      await gamesStore.getGames();
    };
    if (gamesStore.games.length === 0) {
      initialFetch();
    }
  }, []);

  useEffect(() => {
    return () => {
      runInAction(() => {
        subscriptionsStore.subscriptionInfo = {};
      });
    };
  });

  useEffect(() => {
    if (
      subscriptionsStore.subscriptionInfo.gameId.length === 0 ||
      subscriptionsStore.subscriptionInfo.serverId.length === 0 ||
      subscriptionsStore.subscriptionInfo.serverName.length === 0 ||
      subscriptionsStore.subscriptionInfo.serverPrice.length === 0 ||
      subscriptionsStore.subscriptionInfo.userId.length === 0
    ) {
      navigate("/");
    }
  }, [navigate, subscriptionsStore.subscriptionInfo.gameId]);

  useEffect(() => {
    if (typeof window !== "undefined") {
      const loader = document.getElementById("mainpreloader");
      if (loader)
        setTimeout(() => {
          loader.classList.add("fadeOut");
          loader.style.display = "none";
        }, 600);
    }
  }, []);
  return (
    <>
      {/* HEAD */}
      <Helmet>
        <link rel="icon" href="./img/icon.png" />
        <title>Playhost - Game Hosting Website Template</title>
      </Helmet>

      <GlobalStyles />

      {/* LOADER */}
      <div id="mainpreloader">
        <Preloader />
      </div>

      {/* MENU */}
      <div className="home dark-scheme">
        {/* section */}
        <Parallax className="" bgImage={image1} strength={5}>
          <div className="de-gradient-edge-top"></div>
          <div className="de-gradient-edge-bottom"></div>
          <section className="no-bg">
            <div className="container z-9">
              <div className="row align-items-center">
                <div className="col-lg-4 offset-lg-4">
                  <div
                    className="padding40 rounded-10 shadow-soft bg-dark-1"
                    id="login"
                    style={{
                      justifyContent: "center",
                      display: "flex",
                      flexDirection: "column",
                      alignItems: "center",
                      width: "400px",
                    }}
                  >
                    <h4>Подтвержение оплаты</h4>
                    <ul>
                      <li>
                        Сервер: {subscriptionsStore.subscriptionInfo.serverName}
                      </li>
                      <li>
                        Игра:{" "}
                        {gamesStore.games.length &&
                          subscriptionsStore.subscriptionInfo.gameId.length &&
                          gamesStore.games.find(
                            (game) =>
                              game.id ===
                              subscriptionsStore.subscriptionInfo.gameId
                          ).name}
                      </li>
                      <li>
                        Цена: ${subscriptionsStore.subscriptionInfo.serverPrice}
                      </li>
                      <li>Продолжительность: 1 месяц</li>
                    </ul>
                    <div style={{ display: "flex", gap: "24px" }}>
                      <button
                        className="btn-main"
                        onClick={() => navigate("/", { replace: true })}
                      >
                        Отмена
                      </button>
                      <button
                        className="btn-main"
                        onClick={async () => {
                          const response =
                            await subscriptionsStore.postSubscription(
                              subscriptionsStore.subscriptionInfo.serverPrice,
                              subscriptionsStore.subscriptionInfo.serverId,
                              subscriptionsStore.subscriptionInfo.gameId,
                              subscriptionsStore.subscriptionInfo.userId
                            );
                          if (response) {
                            navigate("/profile", { replace: true });
                          }
                        }}
                      >
                        Продолжить
                      </button>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </section>
        </Parallax>
      </div>
      <ScrollToTopBtn />
    </>
  );
};

export default Cards;
