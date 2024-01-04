import React, { useState } from "react";
import s from "./Checkout.module.css";
import useCart from "../../hooks/useCart";
import Swal from "sweetalert2";
import { fortmatCurrency } from "../../../utils/formatCurrency";
import { MdDelete } from "react-icons/md";
import CheckOutModal from "../../components/CheckOutModal/CheckOutModal";
import { useNavigate } from "react-router";

const Checkout = () => {
  const [isOpenModal, setIsOpenModal] = useState(false);
  const navigate = useNavigate();

  const { listCarts, total, setListCarts, deleteCarts } = useCart();
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

  const handleContainerClick = (event, data, quantity) => {
    event.stopPropagation();
    if (event.target.tagName === "BUTTON") {
      return;
    }
    setListCarts(data, quantity);
  };

  const handleOpenModal = () => {
    setIsOpenModal(!isOpenModal);
  };

  return (
    <div className={s.container}>
      <div className={s.wrapper}>
        <h2>{`Giỏ hàng(${listCarts.length})`}</h2>
        <ul className={s.listCart}>
          {listCarts?.map((item) => (
            <li
              className={s.cartItem}
              key={item.id}
              onClick={(e) => handleClickCard(e, item?.id)}
            >
              <div className={s.itemContent}>
                <div className={s.contentLeft}>
                  <img
                    src={import.meta.env.VITE_BASE_IMAGE + item.image}
                    alt={item.name}
                  />
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
      </div>
      <div className={s.checkOutWrapper}>
        <h1>Thống kê chi tiết</h1>
        <div className={s.list}>
          <div className={s.item}>
            <span>Tổng tiền</span>
            <span>{fortmatCurrency(total)}</span>
          </div>
          <div className={s.item}>
            <span>Thuế</span>
            <span>{fortmatCurrency(0)}</span>
          </div>
          <div className={s.item}>
            <span>Tổng</span>
            <h2>{fortmatCurrency(total)}</h2>
          </div>
        </div>
        <button onClick={handleOpenModal}>Thanh toán</button>
      </div>
      {isOpenModal && <CheckOutModal handleClickOutside={handleOpenModal} />}
    </div>
  );
};

export default Checkout;
