import { observer } from "mobx-react";
import React, { useEffect } from "react";
import { Route, Routes, useNavigate } from "react-router-dom";
import Home from "../src/pages/home";
import Games from "../src/pages/games";
import Pricing from "../src/pages/pricing";
import Location from "../src/pages/location";
import Knowledgebase from "../src/pages/knowledgebase";
import Faq from "../src/pages/faq";
import Contact from "../src/pages/contact";
import News from "../src/pages/news";
import About from "../src/pages/about";
import Affliate from "../src/pages/affliate";
import Login from "../src/pages/login";
import Register from "../src/pages/register";
import UseStores from "./hooks/useStores";
import Profile from "./pages/profile";
import Cards from "./section-pages/Cards";

const routes = [
  { path: "/", element: <Home /> },
  { path: "/games", element: <Games /> },
  { path: "/pricing/:id", element: <Pricing /> },
  { path: "/location", element: <Location /> },
  { path: "/knowledgebase", element: <Knowledgebase /> },
  { path: "/faq", element: <Faq /> },
  { path: "/contact", element: <Contact /> },
  { path: "/news", element: <News /> },
  { path: "/about", element: <About /> },
  { path: "/affliate", element: <Affliate /> },
  { path: "/login", element: <Login /> },
  { path: "/register", element: <Register /> },
  { path: "/profile", element: <Profile /> },
  { path: "/order", element: <Cards /> },
];

const Navigation = () => {
  const { userStore } = UseStores();
  const navigate = useNavigate();

  useEffect(() => {
    if (
      userStore.token.length === 0 &&
      !["login", "register"].includes(
        window.location.href.split("/")[
          window.location.href.split("/").length - 1
        ]
      )
    ) {
      navigate("/login");
    }
  }, [navigate, userStore.token]);

  // useEffect(() => {
  //   if (
  //     !userStore.token.length &&
  //     !["login", "register"].includes(
  //       window.location.href.split("/")[
  //         window.location.href.split("/").length - 1
  //       ]
  //     )
  //   ) {
  //     navigate("/login");
  //   } else {
  //     navigate("/");
  //   }
  // }, [userStore.token]);

  useEffect(() => {
    if (!!userStore.token.length) {
      userStore.getUserData();
    }
  }, [userStore, userStore.token]);

  return (
    <Routes>
      {routes.map(({ path, element }) => (
        <Route key={path} path={path} element={element} />
      ))}
    </Routes>
  );
};

export default observer(Navigation);
