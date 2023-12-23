import React, { useState } from "react";
import s from "./Search.module.css";
import { CiSearch } from "react-icons/ci";

const Search = ({handleSearch}) => {
  const [keyword, setKeyword] = useState()
  const handleChange = e => {
    const value = e.target.value;
    setKeyword(value)
  }

  const handleClick = () => {
    handleSearch(keyword)
  }

  return (
    <div>
      <div className={s.searchWrapper}>
        <input onChange={(e) => handleChange(e)} value={keyword} className={s.searchInput} />
        <CiSearch className={s.searchIcon} onClick={handleClick}  />
      </div>
    </div>
  );
};

export default Search;
