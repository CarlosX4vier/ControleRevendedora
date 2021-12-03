import React, { useEffect, useLayoutEffect, useMemo, useRef, useState } from 'react';

const Home: React.FC = () => {

    return (
        <div className="container">

            <div className="row">
                <div className="col-12">
                    <h4>Boa tarde!</h4>
                </div>
            </div>

            <div className="flex-row overflow-auto d-flex justify-content-start">
                <div className="col-12 col-md-11 col-xl-3 card card-pink mx-2">
                    <div className="card-body">Estoque</div>
                </div>
                <div className="col-12 col-md-11 col-xl-3 card card-pink mx-2">
                    <div className="card-body">Estoque</div>
                </div>
            </div>


            <div className="row">
                <div className="card">

                </div>
            </div>

        </div>
    );
}

export default Home;