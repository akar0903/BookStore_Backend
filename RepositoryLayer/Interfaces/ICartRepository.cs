﻿using CommonLayer.RequestModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface ICartRepository
    {
        public CartEntity CartAdd(CartModel model, int Id);
    }
}