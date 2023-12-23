import React from "react";
import s from "./Navigation.module.css";
import { useLocation, useNavigate } from "react-router";
import useCategoryStore from "../../hooks/useCategoryStore";

export const LIST_NAV = [
  {
    id: 1,
    name: "Áo nam",
    link: "ao-nam",
  },
  {
    id: 2,
    name: "Quần nam",
    link: "quan-nam",
  },
  {
    id: 3,
    name: "Giày nam",
    link: "giay-nam",
  },
  {
    id: 4,
    name: "Túi xách",
    link: "tui-xach",
  },
  {
    id: 5,
    name: "phụ kiện",
    link: "phu-kien",
  },
];

const Navigation = () => {
  const nvigate = useNavigate();
  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);
  const category = queryParams.get("category");

  const {categories} = useCategoryStore()


  const handleCategoryChange = (id) => {
    nvigate(`/san-pham?danh-muc=${id}`);
  };
  return (
    <ul className={s.nav}>
      {categories?.slice(0,6).map((item) => (
        <li
          key={item.id}
          className={category === item.id ? s.navItemActive : s.navItem}
          onClick={() => handleCategoryChange(item.id)}
        >
          {item.name}
        </li>
      ))}
    </ul>
  );
};

export default Navigation;
