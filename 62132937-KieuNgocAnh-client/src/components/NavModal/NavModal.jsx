import React from "react";
import s from "./NavModal.module.css";
import { IoMdClose } from "react-icons/io";
import { useLocation, useNavigate } from "react-router";
import { LIST_NAV } from "../Navigation/Navigation";

const NavModal = ({ handleClose }) => {
  const nvigate = useNavigate();
  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);
  const category = queryParams.get("category");

  const handleCategoryChange = (e, category) => {
    nvigate(`/san-pham?danh-muc=${category}`);
    handleClose(e);
  };

  const handleStopPropagation = (event) => {
    event.stopPropagation();
  };

  return (
    <div className={s.overlay} onClick={handleClose}>
      <div className={s.container} onClick={handleStopPropagation}>
        <div className={s.header}>
          <h2>MENU</h2>
          <span className={s.close} onClick={handleClose}>
            <IoMdClose size={24} />
          </span>
        </div>
        <ul>
          {LIST_NAV.map((item) => (
            <li
              key={item.id}
              className={category === item.link ? s.navItemActive : s.navItem}
              onClick={(e) => handleCategoryChange(e, item.link)}
            >
              {item.name}
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
};

export default NavModal;
{
  /* <div className={s.container}>
      <div className={s.header}>
        <h2>MENU</h2>
        <span className={s.close} onClick={handleClose}>
          <IoMdClose size={24} />
        </span>
      </div>
    </div> */
}
