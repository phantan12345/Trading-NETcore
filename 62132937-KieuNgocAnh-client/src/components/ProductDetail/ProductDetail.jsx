import React, { useEffect, useState } from "react";
import s from "./ProductDetail.module.css";
import { useNavigate, useParams } from "react-router";
import { deleteProduct, getProduct } from "../../apis/products";
import { Link } from "react-router-dom";
import { fortmatCurrency } from "../../../utils/formatCurrency";
import useCart from "../../hooks/useCart";
import useContextStore from "../../hooks/useContextStore";
import { BsThreeDots } from "react-icons/bs";
import useAuthStore from "../../hooks/useAuthStore";
import Swal from "sweetalert2";

const ProductDetail = () => {
  const [product, setProduct] = useState();
  const [quantity, setQuantity] = useState(1);
  const [isShowMenu, setIsShowMenu] = useState(false);
  const { currentUser } = useAuthStore();
  const navigate = useNavigate();

  const { id } = useParams();
  const { setListCarts } = useCart();
  const { imageUrl } = useContextStore();

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

  const handleToggleMenu = () => {
    setIsShowMenu(!isShowMenu);
  };

  const handleDeleteProduct = () => {
    Swal.fire({
      title: "Xác nhận xóa sản phẩm",
      text: "Bạn sẽ không thể hoàn điều này!",
      icon: "question",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Vâng",
    }).then( async (result) => {
      if (result.isConfirmed) {
        await deleteProduct(id)
        Swal.fire(
          "Xóa thành công!",
          "success"
        );
      }
    });
    navigate("/")
  }

  return (
    <div className={s.container}>
      <div className={s.imageWrapper}>
        <img src={imageUrl + product?.image} alt={product?.name} />
      </div>
      <div className={s.infoWrapper}>
        <div className={s.infoHeader}>
          <div>
            <Link to="/" className={s.link}>
              home /{" "}
            </Link>
            <Link to="/" className={s.link}>
              product /{" "}
            </Link>
            <span style={{ textTransform: "lowercase" }}>{product?.name}</span>
          </div>
          {currentUser?.rolesId === 1 && (
            <div className={s.menuWrapper} onClick={handleToggleMenu}>
              <BsThreeDots className={s.icon} />
              {isShowMenu && (
                <ul className={s.menu}>
                  <li className={s.menuItem} onClick={handleDeleteProduct}>Xóa sản phẩm</li>
                </ul>
              )}
            </div>
          )}
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
