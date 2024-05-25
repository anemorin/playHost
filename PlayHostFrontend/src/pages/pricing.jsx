import React, { useEffect, useState } from "react";
import { Helmet } from "react-helmet-async";
import { Parallax } from "react-parallax";
import Navbar from "../layout/Navbar";
import Preloader from "../layout/preloader";
import Pricelist from "../section-pages/pricelist-horizontal";
import Section1 from "../section-pages/section-1";
import Footer from "../section-pages/footer";
import ScrollToTopBtn from "../layout/ScrollToTop";
import { createGlobalStyle } from "styled-components";
import UseStores from "../hooks/useStores";
import { observer } from "mobx-react";

const image2 = "./img/background/subheader-game.webp";

const GlobalStyles = createGlobalStyle`

`;

const Pricing = () => {
  const { gamesStore } = UseStores();
  const id = window.location.pathname.split("/")[2];
  const [currentGame, setCurrentGame] = useState();

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

  useEffect(() => {
    const initialFetch = async () => {
      await gamesStore.getGames();
    };

    if (!gamesStore.games.length) {
      initialFetch();
    }
    setCurrentGame(gamesStore.games.find((game) => game.id === id));
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
        {currentGame && (
          <Parallax className="bgcolor" bgImage={image2} strength={300}>
            <div className="de-gradient-edge-bottom"></div>
            <section className="no-bg">
              <div className="container z-1000">
                <div className="row gx-5 align-items-center">
                  <div className="col-lg-2 d-lg-block d-none">
                    <img src={currentGame.image} className="img-fluid" alt="" />
                  </div>
                  <div className="col-lg-6">
                    <div className="subtitle mb-3">Хостинг</div>
                    <h2 className="mb-0">{currentGame.name}</h2>
                  </div>
                </div>
              </div>
            </section>
          </Parallax>
        )}

        {/* section */}
        <section className="no-top">
          <Pricelist id={id} />
        </section>

        {/* section */}
        <section className="no-top">
          <Section1 />
        </section>

        {/* footer */}
        <Footer />
      </div>
      <ScrollToTopBtn />
    </>
  );
};

export default observer(Pricing);
