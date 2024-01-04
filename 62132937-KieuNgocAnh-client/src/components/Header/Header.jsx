import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { FaUser } from "react-icons/fa";
import { IoMdList } from "react-icons/io";
import { FaOpencart } from "react-icons/fa";
import logo from "../../assets/logo.jpg"

import Navigation from "../Navigation/Navigation";
import Search from "../Search/Search";
import CartModal from "../CartModal/CartModal";
import useCart from "../../hooks/useCart";
import s from "./Header.module.css";
import NavModal from "../NavModal/NavModal";
import useAuthStore from "../../hooks/useAuthStore";
import { getCurrentUser } from "../../apis/user";

const Header = () => {
  const [isOpenModal, setIsOpenModal] = useState(false);
  const [isShowMenu, setIsShowMenu] = useState(false);
  const [isShowNav, setIsShowNav] = useState(false);

const nvigate = useNavigate();

  const [currentUser , setCurrentUser] = useState()
  const { token, logout, setUser } = useAuthStore();
  const { listCarts } = useCart();

  useEffect(() => {
    (async function ()  {
      const respone = await getCurrentUser();
      setCurrentUser(respone)
      setUser(respone)
    })()
  },[])


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

  const handleLogout = () => {
    logout();
  };

  const handleSearch = (keyword) => {
    nvigate(`/tim-kiem?tu-khoa=${keyword}`);
  }


  return (
    <div className={s.header}>
      <div className={s.nav}>
        <Link to="/" className={s.logo}>
          <img src={logo} alt="MEME SHOP" />
        </Link>
        <Navigation />
      </div>
      <div className={s.search}>
        <Search handleSearch={handleSearch} />
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
              {token && (
                <>
                  <li>
                    <Link to="/tai-khoan" className={s.link}>
                      Thông tin tài khoản
                    </Link>
                  </li>
                  <li>
                    <Link
                      onClick={handleLogout}
                      to="/dang-nhap"
                      className={s.link}
                    >
                      Đăng xuất
                    </Link>
                  </li>
                </>
              )}
              {!token && (
                <>
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
                </>
              )}
              {/* ROLE ADMIN */}
              {currentUser?.roleId === 2 && (
                <li>
                   <Link to="/them-san-pham" className={s.link}>
                      Thêm sản phẩm
                    </Link>
                </li>
              )}
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
