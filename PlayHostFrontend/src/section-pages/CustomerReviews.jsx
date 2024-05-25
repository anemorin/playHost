import { Pagination } from "swiper/modules";
import { Swiper, SwiperSlide } from "swiper/react";
import UseStores from "../hooks/useStores";
import { observer } from "mobx-react";
import { useEffect } from "react";
import * as dayjs from "dayjs";

const Customerreviews = () => {
  const { reviewsStore } = UseStores();

  useEffect(() => {
    const initialFetch = async () => {
      await reviewsStore.getReviewsList();
    };
    initialFetch();
  }, []);

  return (
    <>
      <div className="container">
        <div className="row">
          <div className="col-md-12">
            <div className="subtitle mb20">Отзывы</div>
            <h2 className="wow fadeInUp">
              {reviewsStore.reviews.length
                ? `${reviewsStore.reviews.reduce((acc, cur) => acc + cur.rate, 0) / reviewsStore.reviews.length}/5`
                : "---"}
            </h2>
            <div className="spacer-20"></div>
          </div>
        </div>
      </div>
      <Swiper
        className="smallslider"
        // install Swiper modules
        modules={[Pagination]}
        spaceBetween={20}
        slidesPerView="auto"
        pagination={{ clickable: true }}
        centeredSlides
        loop
        slideToClickedSlide
      >
        {reviewsStore.reviews.length ? (
          reviewsStore.reviews.map((review) => (
            <SwiperSlide>
              <div className="swiper-inner" style={{ height: "150px" }}>
                <div className="de_testi type-2" style={{ height: "100%" }}>
                  <blockquote
                    style={{
                      height: "100%",
                      display: "flex",
                      flexDirection: "column",
                      justifyContent: "center",
                      gap: "16px",
                    }}
                  >
                    <div className="de-rating-ext">
                      <span className="d-stars">
                        {[...Array(review.rate)].map((e, i) => (
                          <i className="fa fa-star"></i>
                        ))}
                      </span>
                    </div>
                    <div className="de_testi_by">
                      <span>Создан: </span>
                      <span>
                        {dayjs(review.createdAt).format("HH:mm DD-MM-YYYY")}
                      </span>
                    </div>
                  </blockquote>
                </div>
              </div>
            </SwiperSlide>
          ))
        ) : (
          <SwiperSlide>
            <div className="swiper-inner">
              <div className="de_testi type-2">
                <blockquote>
                  <div className="de-rating-ext">
                    <span className="d-stars">---</span>
                  </div>
                  <div className="de_testi_by">---</div>
                </blockquote>
              </div>
            </div>
          </SwiperSlide>
        )}
      </Swiper>
    </>
  );
};
export default observer(Customerreviews);
