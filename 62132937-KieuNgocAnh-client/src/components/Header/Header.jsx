import { useState } from "react";
import { Link } from "react-router-dom";
import { FaUser } from "react-icons/fa";
import { IoMdList } from "react-icons/io";

import Navigation from "../Navigation/Navigation";
import Search from "../Search/Search";
import { FaOpencart } from "react-icons/fa";
import CartModal from "../CartModal/CartModal";
import useCart from "../../hooks/useCart";
import s from "./Header.module.css";
import NavModal from "../NavModal/NavModal";

const Header = () => {
  const [isOpenModal, setIsOpenModal] = useState(false);
  const [isShowMenu, setIsShowMenu] = useState(false);
  const [isShowNav, setIsShowNav] = useState(false);
  const { listCarts } = useCart();

  const handleOpenModal = (e) => {
    e.stopPropagation();
    setIsOpenModal(!isOpenModal);
  };

  const handleShowMenu = (e) => {
    e.stopPropagation();
    setIsShowMenu(!isShowMenu);
  };

  const handleShowNav = (e) => {
    e.stopPropagation();
    setIsShowNav(!isShowNav);
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
      <div className={s.itemRight}>
        <div className={s.navList} onClick={handleShowNav}>
          <IoMdList size={20} />
        </div>
        <div className={s.cart} onClick={handleOpenModal}>
          <FaOpencart className={s.cartIcon} />
          <span className={s.cartQuantity}>{listCarts?.length}</span>
        </div>
        <div className={s.user} onClick={handleShowMenu}>
          <FaUser size={20} />
          {isShowMenu && (
            <ul className={s.menu}>
              <li>
                <Link to="/tai-khoan" className={s.link}>
                  Thông tin tài khoản
                </Link>
              </li>
              <li>
                <Link to="/dang-xuat" className={s.link}>
                  Đăng xuất
                </Link>
              </li>
              <li>
                <Link to="/dang-ky" className={s.link}>
                  Đăng ký
                </Link>
              </li>
              <li>
                <Link to="/dang-nhap" className={s.link}>
                  Đăng nhập
                </Link>
              </li>
            </ul>
          )}
        </div>
      </div>
      {isOpenModal && <CartModal handleClickOutside={handleOpenModal} />}
      {isShowNav && <NavModal handleClose={handleShowNav} />}
    </div>
  );
};

export default Header;
