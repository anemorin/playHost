import React, { useCallback, useState } from "react";
import { Link } from "react-router-dom";
import postDetails from "./data-blog.json";
import UseStores from "../hooks/useStores";
import { observer } from "mobx-react";
import { useEffect } from "react";
import dayjs from "dayjs";
import styled from "styled-components";

const postsPerPage = 6; // Number of posts per page

const StyledTr = styled.tr`
  height: 90px;

  td {
    height: 100%;
    padding: 12px !important;
    align-self: center;
    text-align: center;
  }
`;

const Subscriptions = () => {
  const { subscriptionsStore, gamesStore, serversStore } = UseStores();
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);

  useEffect(() => {
    const initialFetch = async () => {
      await subscriptionsStore.getSubscriptions(currentPage, postsPerPage);
      if (gamesStore.games.length === 0) {
        await gamesStore.getGames();
      }
      if (serversStore.servers.length === 0) {
        await serversStore.getServers();
      }
    };
    initialFetch();
  }, []);

  useEffect(() => {
    setTotalPages(
      Math.ceil(subscriptionsStore.subscriptionsTotalCount / postsPerPage)
    );
  }, [subscriptionsStore.subscriptionsTotalCount])

  useEffect(() => {
    const initialFetch = async (currentPage) => {
      await subscriptionsStore.getSubscriptions(currentPage, postsPerPage);
    };
    initialFetch(currentPage);
    setTotalPages(
      Math.ceil(subscriptionsStore.subscriptionsTotalCount / postsPerPage)
    );
  }, [currentPage]);

  const indexOfLastPost = currentPage * postsPerPage;
  const indexOfFirstPost = indexOfLastPost - postsPerPage;
  const currentPosts = postDetails.slice(indexOfFirstPost, indexOfLastPost);

  const paginate = useCallback(
    (pageNumber) => {
      if (pageNumber > 0 && pageNumber <= totalPages) {
        setCurrentPage(pageNumber);
      }
    },
    [totalPages]
  );

  useEffect(() => {
    if (currentPage > totalPages) {
      setCurrentPage(totalPages);
    }
    console.warn(totalPages)
  }, [totalPages]);

  return (
    <div className="container z-9">
      <div className="row">
        <div className="col-md-12">
          <table className="table table-pricing dark-style text-center">
            <colgroup>
              <col style={{ width: "10%" }}></col>
              <col style={{ width: "10%" }}></col>
              <col style={{ width: "15%" }}></col>
              <col style={{ width: "15%" }}></col>
              <col style={{ width: "20%" }}></col>
              <col style={{ width: "15%" }}></col>
              <col style={{ width: "15%" }}></col>
            </colgroup>
            <thead>
              <tr>
                <th scope="col">Сервер</th>
                <th scope="col">Цена</th>
                <th scope="col">Дата начала</th>
                <th scope="col">Дата конца</th>
                <th scope="col">Игра</th>
                <th scope="col">Продление</th>
                <th scope="col">Удаление</th>
              </tr>
            </thead>
            <tbody>
              {subscriptionsStore.subscriptions.length ? (
                subscriptionsStore.subscriptions.map((sub) => (
                  <StyledTr key={sub.id}>
                    <td>
                      {serversStore.servers.length &&
                        serversStore.servers.find(
                          (server) => server.id === sub.serverId
                        ).name}
                    </td>
                    <td>${sub.price}</td>
                    <td>{dayjs(sub.startDate).format("DD/MM/YYYY")}</td>
                    <td>{dayjs(sub.endDate).format("DD/MM/YYYY")}</td>
                    <td>
                      {gamesStore.games.length &&
                        gamesStore.games.find((game) => game.id === sub.gameId)
                          .name}
                    </td>
                    <td>
                      <button
                        className="btn-main"
                        style={{ width: "80%" }}
                        onClick={async () => {
                          await subscriptionsStore.addDays(sub.id);
                          await subscriptionsStore.getSubscriptions(
                            currentPage,
                            postsPerPage
                          );
                          alert("С вашей карты были сняты все деньги");
                        }}
                      >
                        Продлить на месяц
                      </button>
                    </td>
                    <td>
                      <button
                        className="btn-main"
                        style={{ width: "70%" }}
                        onClick={async () => {
                          await subscriptionsStore.delete(sub.id);
                          await subscriptionsStore.getSubscriptions(
                            currentPage,
                            postsPerPage
                          );
                          setTotalPages(
                            Math.ceil(
                              subscriptionsStore.subscriptionsTotalCount /
                                postsPerPage
                            )
                          );
                        }}
                      >
                        Удалить
                      </button>
                    </td>
                  </StyledTr>
                ))
              ) : (
                <>Тут ничего нет :(</>
              )}
            </tbody>
          </table>
        </div>

        <div className="col-md-12">
          <ul className="pagination">
            {currentPage > 1 && (
              <li>
                <Link
                  to=""
                  onClick={() => paginate(currentPage - 1)}
                  disabled={currentPage === 1}
                >
                  Prev
                </Link>
              </li>
            )}
            {Array.from({ length: totalPages }, (_, i) => (
              <li key={i} className={i + 1 === currentPage ? "active" : ""}>
                <Link to="" onClick={() => paginate(i + 1)}>
                  {i + 1}
                </Link>
              </li>
            ))}
            {Math.max(currentPage, 1) < Math.max(totalPages, 1) && (
              <li>
                <Link
                  to=""
                  onClick={() => paginate(currentPage + 1)}
                  disabled={currentPage === totalPages}
                >
                  Next
                </Link>
              </li>
            )}
          </ul>
        </div>
      </div>
    </div>
  );
};

export default observer(Subscriptions);
