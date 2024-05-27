import React, { useEffect, useState } from "react";
import { Helmet } from "react-helmet-async";
import { Parallax } from "react-parallax";
import { Link, useNavigate } from "react-router-dom";
import Preloader from "../layout/preloader";
import ScrollToTopBtn from "../layout/ScrollToTop";
import { createGlobalStyle } from "styled-components";
import { Formik, Form } from "formik";
import * as Yup from "yup";
import TextField from "../section-pages/ui/fields/TextField";
import UseStores from "../hooks/useStores";

const image1 = "./img/background/2.webp";

const GlobalStyles = createGlobalStyle`
  .react-parallax-bgimage {
    transform: translate3d(-50%, 0, 0px) !important;
  }
  .h-100{
    height: 100vh !important;
  }
`;

export default function Home() {
  const { userStore } = UseStores();
  const navigate = useNavigate();
  const [error, setError] = useState();
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
          <section className="no-bg h-100">
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
                      width: "100%",
                    }}
                  >
                    <h4>Вход</h4>

                    <Formik
                      initialValues={{
                        email: "",
                        password: "",
                      }}
                      onSubmit={async (values, { setSubmitting }) => {
                        const error = await userStore.SignIn(
                          values.email,
                          values.password
                        );
                        console.warn(!error.length)
                        if (!error.length) {
                          navigate("/");
                          setSubmitting(false);
                        } else {
                          setError(error);
                        }
                      }}
                      validationSchema={Yup.object({
                        email: Yup.string()
                          .email("Некоректная почта")
                          .required("Поле обязательно для заполнения"),
                        password: Yup.string().required(
                          "Поле обязательно для заполнения"
                        ),
                      })}
                    >
                      {({ isSubmitting }) => (
                        <Form
                          classList="form-border"
                          id="form_register"
                          style={{ width: "100%" }}
                          onChange={() => {
                            setError();
                          }}
                        >
                          <TextField label="Почта" name="email" />
                          <TextField
                            label="Пароль"
                            name="password"
                            type="password"
                            classList={"field-set"}
                          />
                          <button
                            id="send_message_2"
                            type="submit"
                            disabled={isSubmitting}
                            className="btn-main btn-fullwidth rounded-3"
                            style={{ marginTop: "20px" }}
                          >
                            Войти
                          </button>
                        </Form>
                      )}
                    </Formik>
                    {!!error && (
                      <div
                        style={{
                          color: "red",
                          padding: "12px",
                          fontSize: "16px",
                        }}
                      >
                        {error}
                      </div>
                    )}
                    <Link
                      style={{ marginTop: "12px" }}
                      className="btn-main color-2"
                      to={"/register"}
                    >
                      Ещё нет аккаунта
                    </Link>
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
}
