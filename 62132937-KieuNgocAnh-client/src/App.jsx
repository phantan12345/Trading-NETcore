import { Route, Routes } from "react-router";
import Layout from "./pages/Layout/Layout";
import Home from "./pages/Home/Home";
import Shop from "./components/Shop/Shop";
import Product from "./pages/Product/Product";
import ProductCategory from "./pages/ProductCategory/ProductCategory";
import Login from "./pages/Login/Login";
import Register from "./pages/Register/Register";
import Checkout from "./pages/Checkout/Checkout";
import AddProduct from "./components/AddProduct/AddProduct";

function App() {
  return (
    <>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route path="/" element={<Home />} />
          <Route path="/san-pham" element={<ProductCategory />} />
          <Route path="/san-pham/:id" element={<Product />} />
          <Route path="/cua-hang/:id" element={<Shop />} />
          <Route path="/thanh-toan" element={<Checkout />} />
          <Route path="/them-san-pham" element={<AddProduct />} />
        </Route>
        <Route path="/dang-nhap" element={<Login />} />
        <Route path="/dang-ky" element={<Register />} />
      </Routes>
    </>
  );
}

export default App;
