import { useEffect, useState } from "react";
import type { VendingMachine } from "../../models/vendingMachines";

export const TA = () => {
  const [vendingMachines, setVendingMachines] = useState<VendingMachine[]>([]);

  useEffect(() => {

      const getMachines = async () => {
      const data = await fetch("http://localhost:5208/api/vendingMachines");
      const vendingMachines = await data.json();
      setVendingMachines(vendingMachines);
    };

    getMachines();
  }, []);

  return(
    <div>
        <ul className="flex flex-col gap-2 m-2 p-2">
            {
                vendingMachines.map(m => 
                    <li className="border p-2" key={m.id}>  {m.inventoryNumber }</li>
                )
            }
        </ul>
    </div>
  )
};
