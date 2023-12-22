import Navigation from "../Navigation/Navigation";
import s from "./Header.module.css";
import Search from "../Search/Search";
import { FaOpencart } from "react-icons/fa";
import { useState } from "react";
import CartModal from "../CartModal/CartModal";
import useCart from "../../hooks/useCart";
import { Link } from "react-router-dom";

const Header = () => {
  const [isOpenModal, setIsOpenModal] = useState(false);
  const { listCarts } = useCart();
  const handleOpenModal = (e) => {
    e.stopPropagation();
    setIsOpenModal(!isOpenModal);
  };
  return (
    <div className={s.header}>
      <div className={s.nav}>
        <Link to="/" className={s.logo}>
          LOGO
        </Link>
        <Navigation />
      </div>
      <div className={s.search}>
        <Search />
      </div>
      <div className={s.cart} onClick={handleOpenModal}>
        <FaOpencart className={s.cartIcon} />
        <span className={s.cartQuantity}>{listCarts?.length}</span>
      </div>
      {isOpenModal && <CartModal handleClickOutside={handleOpenModal} />}
    </div>
  );
};

export default Header;
