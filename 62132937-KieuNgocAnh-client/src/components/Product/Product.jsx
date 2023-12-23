import React from "react";
import s from "./Product.module.css";
import { useLocation } from "react-router";

const Product = () => {
  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);
  const category = queryParams.get("danh-muc");
  return (
    <div>
      <h2>{category}</h2>
    </div>
  );
};

export default Product;
