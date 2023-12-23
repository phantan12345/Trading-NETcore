/* eslint-disable react/prop-types */
import s from "./CardProuduct.module.css";
import { RiShoppingCart2Line } from "react-icons/ri";
import { fortmatCurrency } from "../../../utils/formatCurrency";
import useCart from "../../hooks/useCart";
import { useNavigate } from "react-router";

// eslint-disable-next-line react/prop-types
const CardProuduct = ({ product }) => {
  const { setListCarts } = useCart();
  const navigate = useNavigate();

  const handleAddToCart = (e) => {
    setListCarts(product, 1);
    e.stopPropagation();
  };

  const handleClickCard = (id) => {
    console.log(id);
    navigate(`/san-pham/${id}`);
  };

  return (
    <div className={s.container} onClick={() => handleClickCard(product.id)}>
      <div className={s.cartImageWrapper}>
        <img src={import.meta.env.VITE_BASE_IMAGE+ product.image} alt={product.name} className={s.cartImage} />
      </div>
      <div className={s.cartFooter}>
        <div className={s.cartTitle}>
          <h2>{product.name.slice(0, 30)}</h2>
          <span>{fortmatCurrency(product.price)}</span>
        </div>
        <button>
          <RiShoppingCart2Line size={20} onClick={handleAddToCart} />
        </button>
      </div>
    </div>
  );
};

export default CardProuduct;
