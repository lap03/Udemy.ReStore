import { Product } from "../../app/model/product";
import ProductList from "./ProductList";
import { useState, useEffect } from "react";

export default function Catalog() {

    const [products, setProducts] = useState<Product[]>([])

    useEffect(() => {
        fetch("https://localhost:7273/api/products")
            .then(respone => respone.json())
            .then(data => setProducts(data))
    }, [])

    return (
        <>
            <ProductList products={products} />
        </>
    )
}
