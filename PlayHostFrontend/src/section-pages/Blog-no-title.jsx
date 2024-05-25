import React, { useState } from "react";
import { Link } from "react-router-dom";
import postDetails from "./data-blog.json";
import UseStores from "../hooks/useStores";
import { observer } from "mobx-react";
import { useEffect } from "react";
import dayjs from "dayjs";

const postsPerPage = 6; // Number of posts per page

const Section = () => {
  const { newsStore } = UseStores();
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);

  useEffect(() => {
    const initialFetch = async (currentPage) => {
      await newsStore.getNews(currentPage, postsPerPage);
    };
    initialFetch(currentPage);
    setTotalPages(Math.ceil(newsStore.newsTotalCount / postsPerPage));
  }, [currentPage]);

  const indexOfLastPost = currentPage * postsPerPage;
  const indexOfFirstPost = indexOfLastPost - postsPerPage;
  const currentPosts = postDetails.slice(indexOfFirstPost, indexOfLastPost);

  const paginate = (pageNumber) => {
    if (pageNumber > 0 && pageNumber <= totalPages) {
      setCurrentPage(pageNumber);
    }
  };

  return (
    <div className="container">
      <div className="row g-4">
        {newsStore.news.length
          ? newsStore.news.map((post) => (
              <div key={post.id} className="col-lg-4 col-md-6 mb10">
                <div className="bloglist item">
                  <div
                    className="post-content"
                    style={{
                      width: "280px",
                      height: "300px",
                    }}
                  >
                    <div
                      className="post-text"
                      style={{
                        padding: "16px",
                        border: "1px solid gray",
                        borderRadius: "12px",
                        width: "100%",
                        height: "100%",
                        display: "flex",
                        flexDirection: "column",
                        justifyContent: "space-between",
                      }}
                    >
                      <h4>{post.title}</h4>
                      <div className="d-date">{post.text}</div>
                      <p>{dayjs(post.createdAt).format("DD/MM/YYYY")}</p>
                    </div>
                  </div>
                </div>
              </div>
            ))
          : currentPosts.map((post) => <>a</>)}
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
            {currentPage < totalPages && (
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

export default observer(Section);
