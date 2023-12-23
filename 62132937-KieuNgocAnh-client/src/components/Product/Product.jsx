import React, { useEffect, useState } from "react";
import s from "./Product.module.css";
import { useLocation } from "react-router";
import { getProductsByCategoryIdOrKeyword } from "../../apis/products";
import CardProuduct from "../CardProuduct/CardProuduct";

const Product = () => {
  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);
  const [products, setProduct] = useState([]);

  const category = queryParams.get("danh-muc");

  useEffect(() => {
    (async function () {
      const response = await getProductsByCategoryIdOrKeyword(category, null);
      setProduct(response);
    })();
  }, [category]);

  return (
    <div>
      <div className={s.container}>
        {products?.map((product) => (
          <CardProuduct key={product.id} product={product} />
        ))}
      </div>
      {products?.length === 0 && <h1>Không tìm thấy sản phẩm nào</h1>}
    </div>
  );
};

export default Product;
