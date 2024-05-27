import React, { useCallback, useEffect, useState } from "react";
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

const image1 = "./img/background/5.webp";

const GlobalStyles = createGlobalStyle`
  .react-parallax-bgimage {
    transform: translate3d(-50%, 0, 0px) !important;
  }
`;

const Home = () => {
  const navigate = useNavigate();
  const [error, setError] = useState();
  const { userStore } = UseStores();

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
                <div className="col-lg-8 offset-lg-2">
                  <div
                    className="p-5 rounded-10 shadow-soft bg-dark-1"
                    id="login"
                    style={{
                      justifyContent: "center",
                      display: "flex",
                      flexDirection: "column",
                      alignItems: "center",
                    }}
                  >
                    <h4>Регистрация</h4>

                    <Formik
                      initialValues={{
                        firstName: "",
                        lastName: "",
                        role: "user",
                        login: "",
                        email: "",
                        password: "",
                        repeatPassword: "",
                      }}
                      onSubmit={async (values, { setSubmitting }) => {
                        const response = await userStore.Registrations(
                          values.firstName,
                          values.lastName,
                          values.role,
                          values.login,
                          values.email,
                          values.password
                        );
                        if (!error) {
                          navigate("/");
                          setSubmitting(false);
                        } else {
                          setError(error);
                        }

                        setSubmitting(false);
                      }}
                      validationSchema={Yup.object({
                        firstName: Yup.string().required(
                          "Поле обязательно для заполнения"
                        ),
                        lastName: Yup.string().required(
                          "Поле обязательно для заполнения"
                        ),
                        login: Yup.string().required(
                          "Поле обязательно для заполнения"
                        ),
                        email: Yup.string()
                          .email("Некоректная почта")
                          .required("Поле обязательно для заполнения"),
                        password: Yup.string()
                          .min(6, "Минимальная длинна пароля 6 символов")
                          .matches(
                            /[a-z]/,
                            "Пароль должен содержать хотя бы одну строчную букву"
                          )
                          .matches(
                            /[A-Z]/,
                            "Пароль должен содержать хотя бы одну заглавную букву"
                          )
                          .required("Поле обязательно для заполнения"),
                        repeatPassword: Yup.string()
                          .oneOf(
                            [Yup.ref("password"), undefined],
                            "Пароли должны совпадать"
                          )
                          .matches(
                            /[a-zа-я]/,
                            "Пароль должен содержать хотя бы одну строчную букву"
                          )
                          .matches(
                            /[A-ZА-Я]/,
                            "Пароль должен содержать хотя бы одну заглавную букву"
                          )
                          .min(6, "Минимальная длинна пароля 6 символов")
                          .required("Поле обязательно для заполнения"),
                      })}
                    >
                      {({ isSubmitting }) => (
                        <Form
                          classList="form-border"
                          id="contact_form"
                          onChange={() => {
                            setError();
                          }}
                        >
                          <div className="row">
                            <TextField label="Имя" name="firstName" />
                            <TextField label="Фамилия" name="lastName" />
                            <TextField label="Логин" name="login" />
                            <TextField label="Почта" name="email" />
                            <TextField
                              label="Пароль"
                              name="password"
                              type="password"
                            />
                            <TextField
                              label="Повторите пароль"
                              name="repeatPassword"
                              type="password"
                            />
                            <div className="col-lg-6 offset-lg-3 text-center my-3">
                              <div>
                                <button
                                  id="send_message"
                                  type="submit"
                                  disabled={isSubmitting}
                                  className="btn-main color-2"
                                >
                                  Регистрация
                                </button>
                              </div>
                            </div>
                          </div>
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
                      to={"/login"}
                    >
                      Уже есть аккаунт
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
};

export default Home;
