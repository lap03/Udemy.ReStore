import { useEffect, useState } from "react";
import { Basket } from "../../app/model/basket";
import agent from "../../app/api/agent";
import { Button, Typography } from "@mui/material";
import { Link } from "react-router-dom";

export default function BasketPage () {
    const [loading, setLoading] = useState(true);
    const [basket,setBasket] = useState<Basket | null>(null);

    useEffect(() => {
        agent.Basket.get()
            .then(basket => setBasket(basket))
            .catch(error => console.log(error))
            .finally(() => setLoading(false))
    },[])

    if(!basket) return <Typography variant="h3">your basket is empty</Typography>
    
    return(
        <Button component={Link} to="/checkout" variant="contained" size="large" fullWidth>Checkout</Button>
    )
}