import React from "react";
import s from "./About.module.css";
import { AiOutlineShoppingCart } from "react-icons/ai";
import { BsShieldCheck, BsCoin } from "react-icons/bs";
import { CiMedal } from "react-icons/ci";
const LIST = [
  {
    icon: <AiOutlineShoppingCart size={40} />,
    label: "Giao Hàng Miễn Phí",
    description:
      "Trạng thái đơn hàng của bạn luôn được cập nhật chi tiết kể từ khi bạn đặt hàng",
  },
  {
    icon: <BsShieldCheck size={40} />,
    label: "Thanh toán an toàn 100%",
    description:
      "Số tiền bạn thanh toán sẽ được chuyển đến người bán sau khi bạn nhận được hàng. Chúng tôi luôn bảo vệ bạn!",
  },
  {
    icon: <CiMedal size={40} />,
    label: "Đảm bảo chất lượng",
    description:
      "Tận hưởng cảm giác mua sắm tuyệt vời với những sản phẩm chất lượng đến từ các Shop bán hàng uy tín",
  },
  {
    icon: <BsCoin size={40} />,
    label: "Tiết kiệm - đảm bảo",
    description:
      "Tận hưởng các chương trình khuyến mãi hấp dẫn, siêu tiết kiệm đến từ các Shop bán hàng uy tín nhất.",
  },
];

const About = () => {
  return (
    <ul className={s.aboutWrapper}>
      {LIST.map((item) => (
        <li key={item.label} className={s.aboutItem}>
          {item.icon}
          <span className={s.itemLabel}>{item.label}</span>
          <span className={s.itemDescription}>{item.description}</span>
        </li>
      ))}
    </ul>
  );
};

export default About;
