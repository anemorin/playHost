import React, { useEffect } from "react";
import { Helmet } from "react-helmet-async";
import Navbar from "../layout/Navbar";
import Preloader from "../layout/preloader";
import Footer from "../section-pages/footer";
import ScrollToTopBtn from "../layout/ScrollToTop";
import { createGlobalStyle } from "styled-components";
import { Link } from "react-router-dom";

const image1 = "./img/background/subheader-about.webp";

const GlobalStyles = createGlobalStyle`

`;

const UndefinedPage = () => {
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

        <section
          style={{padding: "364px 64px"}}
        >
        <h1 >
          404: Такой страницы нет
        </h1>
        <Link to={'/'} >Вернуться на главную</Link>
        </section>

      </div>
      <ScrollToTopBtn />
    </>
  );
}

export default UndefinedPage;
