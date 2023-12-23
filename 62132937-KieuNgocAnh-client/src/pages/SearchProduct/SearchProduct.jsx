import { useLocation } from "react-router";
import s from "./SearchProduct.module.css"
import { useEffect, useState } from "react";
import { getProductsByCategoryIdOrKeyword } from "../../apis/products";
import CardProuduct from "../../components/CardProuduct/CardProuduct";

export const SearchProduct = () => {
    const location = useLocation();
  const queryParams = new URLSearchParams(location.search);
  const [products, setProduct] = useState([]);

  const keyword = queryParams.get("tu-khoa");

  useEffect(() => {
    (async function () {
      const response = await getProductsByCategoryIdOrKeyword(null, keyword);
      console.log(keyword);
      setProduct(response);
    })();
  }, [keyword]);

  console.log(keyword);

    return  <div>
    <div className={s.container}>
      {products?.map((product) => (
        <CardProuduct key={product.id} product={product} />
      ))}
    </div>
    {products?.length === 0 && <h1>Không tìm thấy sản phẩm nào</h1>}
  </div>
}

