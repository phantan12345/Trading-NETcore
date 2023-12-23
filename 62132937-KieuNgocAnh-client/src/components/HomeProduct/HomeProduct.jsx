import { useEffect, useState } from "react";
import s from "./HomeProduct.module.css";
import { getProducts } from "../../apis/products";
import CardProuduct from "../CardProuduct/CardProuduct";

const HomeProduct = () => {
  const [products, setProducts] = useState([]);
  useEffect(() => {
    (async function () {
      const data = await getProducts();
      setProducts(data);
    })();
  }, []);
  return (
    <div className={s.wrapper}>
      <h2>New arrival</h2>
      <div className={s.container}>
        {products.map((product) => (
          <CardProuduct key={product.id} product={product} />
        ))}
      </div>
    </div>
  );
};

export default HomeProduct;
