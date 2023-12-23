import React, { useEffect } from "react";
import { Outlet } from "react-router";
import Header from "../../components/Header/Header";
import s from "./Layout.module.css";
import useCategoryStore from "../../hooks/useCategoryStore";
import { getCategories } from "../../apis/categogies";

const Layout = () => {
  const { setCategories } = useCategoryStore();
  useEffect(() => {
    (async function () {
      try {
        const response = await getCategories();
        setCategories(response);
      } catch (error) {
        alert(error.message);
      }
    })();
  }, []);
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
