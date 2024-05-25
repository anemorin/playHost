import React from "react";
import { Link } from "react-router-dom";

const footer = () => {
  return (
    <footer>
      <div className="container">
        <div className="row gx-5">
          <div className="col-lg-4">
            <img src="./img/logo.png" alt="" />
            <div className="spacer-20"></div>
          </div>
          <div className="col-lg-4">
            <div className="row">
              <div className="col-lg-6 col-sm-6">
                <div className="widget">
                  <h5>Страницы</h5>
                  <ul
                    style={{
                      display: "flex",
                      width: "100%",
                      flexDirection: "row",
                    }}
                  >
                    <li style={{ display: "flex" }}>
                      <Link style={{ width: "150px" }} to="/">
                        Гланая
                      </Link>
                    </li>
                    <li style={{ display: "flex" }}>
                      <Link style={{ width: "150px" }} to="/games">
                        Игры
                      </Link>
                    </li>
                    <li style={{ display: "flex" }}>
                      <Link style={{ width: "150px" }} to="/about">
                        О нас
                      </Link>
                    </li>
                    <li style={{ display: "flex" }}>
                      <Link style={{ width: "150px" }} to="/affliates">
                        Программа лояльности
                      </Link>
                    </li>
                    <li style={{ display: "flex" }}>
                      <Link style={{ width: "150px" }} to="/locations">
                        Сервера
                      </Link>
                    </li>
                    <li style={{ display: "flex" }}>
                      <Link style={{ width: "150px" }} to="/news">
                        Новости
                      </Link>
                    </li>
                  </ul>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div className="subfooter">
        <div className="container">
          <div className="row">
            <div className="col-lg-6 col-sm-6">
              Copyright 2023 - Playhost by Designesia
            </div>
            <div className="col-lg-6 col-sm-6 text-lg-end text-sm-start">
              <ul className="menu-simple">
                <li>
                  <Link to="/">Terms &amp; Conditions</Link>
                </li>
                <li>
                  <Link to="/">Privacy Policy</Link>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
    </footer>
  );
};

export default footer;
