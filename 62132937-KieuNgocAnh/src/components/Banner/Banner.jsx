import React from "react";
import s from "./Banner.module.css";
import bannerImage from "../../assets/banner.jpg";

const Banner = () => {
  return (
    <div className={s.bannerWrapper}>
      <img className={s.bannerImage} alt="Banner" src={bannerImage} />
      <div className={s.bannerTitle}>
        <h2>
          Nâng tầm phong cách với <br /> bộ sưu tập mới!
        </h2>
        <button>Mua ngay</button>
      </div>
    </div>
  );
};

export default Banner;
