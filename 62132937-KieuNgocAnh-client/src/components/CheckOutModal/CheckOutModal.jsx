import React from "react";
import s from "./CheckOutModal.module.css";
import { IoMdClose } from "react-icons/io";
import { useForm } from "react-hook-form";
import * as z from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import useCart from "../../hooks/useCart";
import { checkout } from "../../apis/cart";
import Swal from "sweetalert2";


const schema = z.object({
  address: z.string().min(6),
  phone: z.string().min(6),
});

const CheckOutModal = ({ handleClickOutside }) => {
const {listCarts, deleteCarts} = useCart();

  const {
    register,
    handleSubmit,
    watch,
    formState: { errors, isSubmitting },
  } = useForm({
    defaultValues: {
      address: "",
      phone: "",
    },
    resolver: zodResolver(schema),
    reValidateMode: "onBlur",
    mode: "onBlur",
  });

  const onSubmit = (form) => {
    const carts = listCarts?.map((item) => {
      const newItem = {
        id: item.id,
        count: item.quantity
      }
      deleteCarts(item.id)
      return newItem;
    })
    const data = {
      carts,
      address: form.address,
      phone: form.phone
    }
    Swal.fire({
      title: "Xác nhận thanh toán",
      text: "Bạn sẽ không thể hoàn điều này!",
      icon: "question",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Vâng",
    }).then( async (result) => {
      if (result.isConfirmed) {
        await checkout(data)
        Swal.fire(
          "Thanh toán thành công!",
          "success"
        );
      }
    });
    
  };

  const handleStopPropagation = (event) => {
    event.stopPropagation();
  };



  return (
    <div className={s.overlay} onClick={handleClickOutside}>
      <div className={s.container} onClick={handleStopPropagation}>
        <header className={s.header}>
          <h2>Thanh toán</h2>
          <span onClick={handleClickOutside}>
            <IoMdClose size={26} />
          </span>
        </header>
        <section className={s.content}>
          <form className={s.form}>
            <div className={s.inputField}>
              <label>Địa chỉ</label>
              <input {...register("address")} />
              {errors.address && (
                <span className={s.error}>Ít nhất 6 ký tự</span>
              )}
            </div>
            <div className={s.inputField}>
              <label>Số điện thoại</label>
              <input {...register("phone")} />
              {errors.phone && (
                <span className={s.error}>Ít nhất 6 ký tự</span>
              )}
            </div>
          </form>
          <div className={s.contentRight}>
            <ul className={s.note}>
              <li>Điền chính nơi nhận hàng</li>
              <li>Xác nhận lại số lượng đơn hàng </li>
              <li>Kiểm tra lại tổng tiền đơn hàng</li>
              <li>Vui lòng cung cung cấp đầy đủ thông tin và chính xác</li>
            </ul>
          </div>
        </section>
        <footer className={s.footer}>
          <button onClick={handleSubmit(onSubmit)}>Thanh toán</button>
        </footer>
      </div>
    </div>
  );
};

export default CheckOutModal;
