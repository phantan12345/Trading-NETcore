import React from "react";
import { Outlet } from "react-router";
import Header from "../../components/Header/Header";
import s from "./Layout.module.css";

const Layout = () => {
  return (
    <div>
      <Header />
      <div className={s.container}>
        <Outlet />
      </div>
    </div>
  );
};

export default Layout;
