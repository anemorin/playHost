import React, { useEffect } from "react";
import { Helmet } from "react-helmet-async";
import { Parallax } from "react-parallax";
import Navbar from "../layout/Navbar";
import Preloader from "../layout/preloader";
import Footer from "../section-pages/footer";
import ScrollToTopBtn from "../layout/ScrollToTop";
import { createGlobalStyle } from "styled-components";
import Subscriptions from "../section-pages/Subscriptions";
import UseStores from "../hooks/useStores";
import { removeToken } from "../services/ApiConnection";
import { useNavigate } from "react-router-dom";
import { observer } from "mobx-react";

const image1 = "../../img/background/subheader-news.webp";

const GlobalStyles = createGlobalStyle`

`;
const Profile = () => {
  const {
    userStore,
    gamesStore,
    subscriptionsStore,
    serversStore,
    newsStore,
    reviewsStore,
  } = UseStores();

  const navigate = useNavigate();
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
        <header id="header-wrap">
          <Navbar />
        </header>

        {/* section */}
        <Parallax className="" bgImage={image1} strength={5}>
          <section className="no-bg">
            <div className="container z-9">
              <div className="row">
                <div className="col-lg-12">
                  <div className="subtitle wow fadeInUp mb-3">
                    Это ваша страница
                  </div>
                </div>
                <div className="col-lg-6">
                  <h2>Профиль</h2>
                </div>
              </div>
            </div>
          </section>
        </Parallax>

        <div
          style={{
            padding: "36px",
            borderRadius: "12px",
            border: "1px solid gray",
            display: "flex",
            justifyContent: "space-between",
          }}
        >
          {userStore.email}
          <button
            className="btn-main"
            onClick={() => {
              userStore.clearStore();
              gamesStore.clearStore();
              subscriptionsStore.clearStore();
              serversStore.clearStore();
              newsStore.clearStore();
              reviewsStore.clearStore();
              removeToken();
              navigate("/login");
            }}
          >
            Выход
          </button>
        </div>

        {/* section */}
        <section>
          <Subscriptions />
        </section>

        {/* footer */}
        <Footer />
      </div>
      <ScrollToTopBtn />
    </>
  );
};

export default observer(Profile);
