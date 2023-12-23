import React from "react";
import s from "./CartModal.module.css";
import useCart from "../../hooks/useCart";
import { MdDelete } from "react-icons/md";
import { fortmatCurrency } from "../../../utils/formatCurrency";
import Swal from "sweetalert2";
import { useNavigate } from "react-router";
import { IoMdClose } from "react-icons/io";

const CartModal = ({ handleClickOutside }) => {
  const { listCarts, setListCarts, deleteCarts, total } = useCart();
  const navigate = useNavigate();

  const handleContainerClick = (event, data, quantity) => {
    event.stopPropagation();
    if (event.target.tagName === "BUTTON") {
      return;
    }
    setListCarts(data, quantity);
  };

  const handleDeleteItem = (event, id) => {
    event.stopPropagation();
    Swal.fire({
      title: "Bạn chắc chắn muốn xóa sản phẩm này?",
      text: "Bạn sẽ không thể hoàn điều này!",
      icon: "question",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Vâng, xóa nó!",
    }).then((result) => {
      if (result.isConfirmed) {
        deleteCarts(id);
        Swal.fire(
          "Xóa thành công!",
          "Sản phẩm đã được xóa thành công!",
          "success"
        );
      }
    });
  };

  const handleClickCard = (event, id) => {
    event.stopPropagation();
    navigate(`/san-pham/${id}`);
  };

  const handleStopPropagation = (event) => {
    event.stopPropagation();
  };

  const handleCheckOut = (event) => {
    event.stopPropagation();
    handleClickOutside(event);
    navigate(`/thanh-toan`);
  };

  return (
    <div className={s.overlay} onClick={handleClickOutside}>
      <div className={s.container} onClick={handleStopPropagation}>
        <div className={s.header}>
          <h1>{`Giỏ hàng(${listCarts?.length})`}</h1>
          <span className={s.close} onClick={handleClickOutside}>
            <IoMdClose size={28} />
          </span>
        </div>
        <ul className={s.listCart}>
          {listCarts?.map((item) => (
            <li
              className={s.cartItem}
              key={item.id}
              onClick={(e) => handleClickCard(e, item?.id)}
            >
              <div className={s.itemContent}>
                <div className={s.contentLeft}>
                  <img src={item.image} alt={item.name} />
                  <div className={s.itemTitle}>
                    <h2>{item.name.slice(0, 30)}</h2>
                    <p>{fortmatCurrency(item.price)}</p>
                  </div>
                </div>
                <MdDelete
                  size={24}
                  className={s.iconDelete}
                  onClick={(e) => handleDeleteItem(e, item.id)}
                />
              </div>
              <div className={s.itemQuantity}>
                <p onClick={(e) => handleContainerClick(e, item, -1)}>-</p>
                <span>{item.quantity}</span>
                <p onClick={(e) => handleContainerClick(e, item, 1)}>+</p>
              </div>
            </li>
          ))}
        </ul>
        <div className={s.cartFooter}>
          <div className={s.cartTotal}>
            <span>Tổng tiền:</span>
            <span>{fortmatCurrency(total)}</span>
          </div>
          <button onClick={handleCheckOut}>Đặt hàng </button>
        </div>
      </div>
    </div>
  );
};

export default CartModal;
