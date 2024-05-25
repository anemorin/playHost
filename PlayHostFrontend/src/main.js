import React, { useEffect } from 'react';
import { BrowserRouter, useLocation } from 'react-router-dom';
import { HelmetProvider } from 'react-helmet-async';
import Router from './Router';

const ScrollToTop = () => {
  const { pathname } = useLocation();

  useEffect(() => {
    window.scrollTo(0, 0);
  }, [pathname]);

  return null;
};


function App() {
  return (
    <HelmetProvider>
      <div>
        <BrowserRouter>
          <ScrollToTop />
          <Router />
        </BrowserRouter>
      </div>
    </HelmetProvider>
  );
}

export default App;
