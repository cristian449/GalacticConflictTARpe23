﻿using IntergalacticConflict.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticConflict.Core.ServiceInterface
{
    public interface IEmailsServices
    {
        void SendEmail(EmailDto dto);

        void SendEmailToken(EmailTokenDto dto, string token);
    }
}