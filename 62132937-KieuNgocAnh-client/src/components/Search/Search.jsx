import React from "react";
import s from "./Search.module.css";
import { CiSearch } from "react-icons/ci";

const Search = () => {
  return (
    <div>
      <div className={s.searchWrapper}>
        <input className={s.searchInput} />
        <CiSearch className={s.searchIcon} />
      </div>
    </div>
  );
};

export default Search;
