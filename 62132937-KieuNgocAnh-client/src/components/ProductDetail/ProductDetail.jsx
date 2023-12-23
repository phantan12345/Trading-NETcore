import React, { useEffect, useState } from "react";
import s from "./ProductDetail.module.css";
import { useParams } from "react-router";
import { getProduct } from "../../apis/products";
import { Link } from "react-router-dom";
import { fortmatCurrency } from "../../../utils/formatCurrency";
import useCart from "../../hooks/useCart";

const ProductDetail = () => {
  const [product, setProduct] = useState();
  const [quantity, setQuantity] = useState(1);
  const { id } = useParams();
  const { setListCarts } = useCart();

  useEffect(() => {
    try {
      (async function () {
        console.log(id);
        const response = await getProduct(id);
        setProduct(response);
      })();
    } catch (error) {
      alert(error.message);
    }
  }, [id]);

  const handleQuantityChange = (change) => {
    setQuantity((prevQuantity) => Math.max(1, prevQuantity + change));
  };

  const handleAddToCart = () => {
    setListCarts(product, quantity);
  };

  return (
    <div className={s.container}>
      <div className={s.imageWrapper}>
        <img src={product?.image} alt={product?.name} />
      </div>
      <div className={s.infoWrapper}>
        <div>
          <Link to="/" className={s.link}>
            home /{" "}
          </Link>
          <Link to="/" className={s.link}>
            product /{" "}
          </Link>
          <span style={{ textTransform: "lowercase" }}>{product?.name}</span>
        </div>
        <h1>{product?.name}</h1>
        <div className={s.price}>{fortmatCurrency(product?.price)}</div>
        <div className={s.cartWrapper}>
          <div className={s.itemQuantity}>
            <p onClick={() => handleQuantityChange(-1)}>-</p>
            <span>{quantity}</span>
            <p onClick={() => handleQuantityChange(1)}>+</p>
          </div>
          <button onClick={handleAddToCart} className={s.btn}>
            Thêm vào giỏ hàng
          </button>
        </div>
        <article>
          Lorem ipsum, dolor sit amet consectetur adipisicing elit. Pariatur
          voluptate tempora, laboriosam nesciunt ipsam ducimus ullam nostrum id!
          Consequuntur rem officiis nemo aut eius aliquid ratione sint nobis
          voluptatibus repudiandae!
        </article>
      </div>
    </div>
  );
};

export default ProductDetail;
