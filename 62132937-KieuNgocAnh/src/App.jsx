import { Route, Routes } from "react-router";
import Layout from "./pages/Layout/Layout";
import Home from "./pages/Home/Home";
import Shop from "./components/Shop/Shop";
import Product from "./pages/Product/Product";
import ProductCategory from "./pages/ProductCategory/ProductCategory";

function App() {
  return (
    <>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route path="/" element={<Home />} />
          <Route path="/san-pham" element={<ProductCategory />} />
          <Route path="/san-pham/:id" element={<Product />} />
          <Route path="/cua-hang/:id" element={<Shop />} />
        </Route>
      </Routes>
    </>
  );
}

export default App;
