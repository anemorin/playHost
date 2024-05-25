import { Pagination } from "swiper/modules";
import { Swiper, SwiperSlide } from "swiper/react";
import { Link } from "react-router-dom";
import UseStores from "../hooks/useStores";
import { observer } from "mobx-react";
import { useEffect } from "react";

const Customerreviews = () => {
  const { gamesStore } = UseStores();

  useEffect(() => {
    const initialFetch = async () => {
      await gamesStore.getGames();
    };
    initialFetch();
  }, []);

  return (
    <div className="container-fluid">
      <div className="row">
        <Swiper
          key={gamesStore.games ? gamesStore.games.length : 0}
          className="smallslider"
          // install Swiper modules
          modules={[Pagination]}
          spaceBetween={25}
          slidesPerView="4"
          onSlidesLengthChange={(swiper) => {
            swiper.update();
          }}
          breakpoints={{
            1200: {
              slidesPerView: 4,
            },
            992: {
              slidesPerView: 3,
            },
            500: {
              slidesPerView: 2,
            },
            320: {
              slidesPerView: 1,
            },
          }}
          pagination={{
            clickable: true,
            dynamicBullets: true,
            dynamicMainBullets: 1, // Set the minimum number of bullets to display
          }}
          centeredSlides
          loop
          slideToClickedSlide
          onInit={async (swiper) => {
            await gamesStore.getGames();
            swiper.update();
          }}
        >
          {gamesStore.games.length ? (
            gamesStore.games.map((game) => (
              <SwiperSlide observer key={game.id}>
                <div className="swiper-inner">
                  <div className="de-item wow">
                    <div className="d-overlay">
                      <div className="d-label">20% OFF</div>
                      <div className="d-text">
                        <h4>{game.name}</h4>
                        <p className="d-price">
                          от <span className="price">${game.price}</span> в
                          месяц
                        </p>
                        <Link
                          className="btn-main btn-fullwidth"
                          to={`/pricing/${game.id}`}
                        >
                          Оформить
                        </Link>
                      </div>
                    </div>
                    <img src={game.image} className="img-fluid " alt="" />
                  </div>
                </div>
              </SwiperSlide>
            ))
          ) : (
            <SwiperSlide>
              <div className="swiper-inner">
                <div className="de-item wow">
                  <div className="d-overlay">
                    <div className="d-label">20% OFF</div>
                    <div className="d-text">
                      <h4>загрузка...</h4>
                      <p className="d-price">---</p>
                      <Link className="btn-main btn-fullwidth" to="/">
                        ----
                      </Link>
                    </div>
                  </div>
                  <img
                    src=""
                    className="img-fluid "
                    alt=""
                    style={{ width: "377px", height: "586px" }}
                  />
                </div>
              </div>
            </SwiperSlide>
          )}
        </Swiper>
      </div>
    </div>
  );
};

export default observer(Customerreviews);
