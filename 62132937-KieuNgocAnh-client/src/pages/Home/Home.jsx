import React from "react";
import s from "./Home.module.css";
import Header from "../../components/Header/Header";
import Banner from "../../components/Banner/Banner";
import About from "../../components/About/About";
import HomeProduct from "../../components/HomeProduct/HomeProduct";

const Home = () => {
  return (
    <div className={s.container}>
      <Banner />
      <About />
      <HomeProduct />
    </div>
  );
};

export default Home;
