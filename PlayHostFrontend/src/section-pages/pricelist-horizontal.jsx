import React, { useCallback, useState } from "react";
import ReactFlagsSelect from "react-flags-select";
import { Link, useNavigate } from "react-router-dom";
import UseStores from "../hooks/useStores";
import { observer } from "mobx-react";
import { useEffect } from "react";

const Server = (props) => {
  const { serversStore, subscriptionsStore, userStore } = UseStores();
  const navigate = useNavigate();
  useEffect(() => {
    const initialFetch = async () => {
      await serversStore.getServers();
    };
    initialFetch();
  }, []);

  const [selected, setSelected] = useState("RU");
  const handleSelect = (countryCode) => {
    setSelected(countryCode);
  };

  //switch
  const [isChecked, setIsChecked] = useState(false);
  const handleToggle = () => {
    setIsChecked((prevState) => !prevState);
  };

  const otherElementClassName = isChecked
    ? "other-element active"
    : "other-element";

  const setSubInfo = useCallback(
    (server) => {
      subscriptionsStore.setSubInfo(
        props.id,
        server.name,
        server.price,
        server.id,
        userStore.userId
      );
    },
    [props.id, subscriptionsStore, userStore.userId]
  );

  return (
    <>
      <div className="de-gradient-edge-top"></div>
      <div className="de-gradient-edge-bottom"></div>
      <div className="container z-9">
        <div className="row">
          <div className="col-md-12">
            <table className="table table-pricing dark-style text-center">
              <thead>
                <tr>
                  <th scope="col">Название</th>
                  <th scope="col">Кол-во игроков</th>
                  <th scope="col">Память</th>
                  <th scope="col">Расположение сервера</th>
                  <th scope="col">Цена</th>
                  <th scope="col">Оформить</th>
                </tr>
              </thead>
              <tbody>
                {serversStore.servers.length ? (
                  serversStore.servers
                    .slice()
                    .sort((a, b) => a.ram - b.ram)
                    .map((server) => (
                      <tr
                        className={`de_pricing-table ${otherElementClassName}`}
                        key={server.id}
                      >
                        <th>{server.name}</th>
                        <td>
                          <i className="fa fa-user id-color"></i>{" "}
                          {server.maxUsers}
                        </td>
                        <td>
                          <i className="fa-solid fa-memory id-color"></i>{" "}
                          {server.ram}
                        </td>
                        <td className="d-spc py-4">
                          <ReactFlagsSelect
                            className="flagstable"
                            countries={[
                              "GB",
                              "FR",
                              "DE",
                              "NL",
                              "SE",
                              "FI",
                              "US",
                              "QC",
                              "AU",
                              "BR",
                              "TH",
                              "ID",
                              "RU",
                            ]}
                            customLabels={{
                              GB: "London, England",
                              FR: "Paris, France",
                              DE: "Frankurt, Germany",
                              NL: "Amsterdam, Netherlands",
                              SE: "Stockholm, Sweden",
                              FI: "Helsinki, Finland",
                              US: "Los Angeles, USA",
                              QC: "Quebec, Canada",
                              AU: "Sydney, Australia",
                              BR: "Sau Paulo, Brazil",
                              TH: "Bangkok, Thailand",
                              ID: "Jakarta, Indonesia",
                              RU: "Moskow, Russia",
                            }}
                            selected={selected}
                            onSelect={handleSelect}
                            searchable={false}
                          />
                        </td>
                        <td className="d-spc">
                          <span className="opt-1">${server.price}</span>
                        </td>
                        <td>
                          <Link
                            to="/order"
                            className="btn-main"
                            style={{ width: "80%" }}
                            onClick={() => {
                              setSubInfo(server);
                            }}
                          >
                            ОФОРМИТЬ
                          </Link>
                        </td>
                      </tr>
                    ))
                ) : (
                  <tr className={`de_pricing-table ${otherElementClassName}`}>
                    <th>---</th>
                    <td>
                      <i className="fa fa-user id-color"></i> ---
                    </td>
                    <td>
                      <i className="fa-solid fa-memory id-color"></i> ---
                    </td>
                    <td className="d-spc py-4">
                      <ReactFlagsSelect
                        className="flagstable"
                        countries={[
                          "GB",
                          "FR",
                          "DE",
                          "NL",
                          "SE",
                          "FI",
                          "US",
                          "QC",
                          "AU",
                          "BR",
                          "TH",
                          "ID",
                        ]}
                        customLabels={{
                          GB: "London, England",
                          FR: "Paris, France",
                          DE: "Frankurt, Germany",
                          NL: "Amsterdam, Netherlands",
                          SE: "Stockholm, Sweden",
                          FI: "Helsinki, Finland",
                          US: "Los Angeles, USA",

                          QC: "Quebec, Canada",
                          AU: "Sydney, Australia",
                          BR: "Sau Paulo, Brazil",
                          TH: "Bangkok, Thailand",
                          ID: "Jakarta, Indonesia",
                        }}
                        selected={selected}
                        onSelect={handleSelect}
                        searchable={false}
                      />
                    </td>
                  </tr>
                )}
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </>
  );
};

export default observer(Server);
