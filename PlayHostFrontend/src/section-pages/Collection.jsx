import React, { useEffect } from "react";
import { Link } from "react-router-dom";
import UseStores from "../hooks/useStores";
import { observer } from "mobx-react";

const Collection = () => {
  const { gamesStore } = UseStores();

  useEffect(() => {
    const initialFetch = async () => {
      await gamesStore.getGames();
    };
    initialFetch();
  }, []);

  return (
    <div className="container">
      <div className="row">
        <div className="col-md-6">
          {/* <div className="subtitle mb20">Most complete</div> */}
          <h2 className="wow fadeInUp">Коллекция игр</h2>
          <div className="spacer-20"></div>
        </div>
        {/* <div className="col-lg-6 text-lg-end">
          <Link className="btn-main mb-sm-30" to="/">
            View all games
          </Link>
        </div> */}
      </div>
      <div className="row g-4 sequence">
        {gamesStore.games.length ? (
          gamesStore.games.map((game) => (
            <div className="col-lg-3 col-md-6 gallery-item" key={game.id}>
              <div className="de-item wow">
                <div className="d-overlay">
                  <div className="d-label">20% OFF</div>
                  <div className="d-text">
                    <h4>{game.name}</h4>
                    <p className="d-price">
                      от <span className="price">${game.price}</span> в месяц
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
          ))
        ) : (
          <>dasd</>
        )}
      </div>
    </div>
  );
};

export default observer(Collection);
